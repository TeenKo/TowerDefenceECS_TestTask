using System;
using System.Collections.Generic;
using System.Linq;
using _Core_.States;
using Entitas;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Core_.Tools
{
    public static class GameTools
    {
        public static void TransitionGameState(GameEntity entity, IGameContextState component, bool haveAnimation)
        {
            if (haveAnimation)
            {
                RemoveComponent(entity);
                entity.ReplaceTransitionState(component);
            }
            else
            {
                ChangeGameState(entity, component);
            }
        }

        private static void ChangeGameState(GameEntity entity, IGameContextState component)
        {
            if (CheckTypeEquality(component, entity.stateObjectType.value) == false) return;
            if (entity.hasTransitionState) entity.RemoveTransitionState();
            RemoveComponent(entity);

            foreach (var typeComponent in GameComponentsLookup.componentTypes)
            {
                if (component.ToString() != typeComponent.ToString()) continue;

                var componentIndex = Array.IndexOf(GameComponentsLookup.componentTypes, typeComponent);
                entity.AddComponent(componentIndex, (IComponent)component);
                break;
            }
        }

        private static void RemoveComponent(GameEntity entity)
        {
            foreach (var indexComponent in entity.GetComponentIndices())
            {
                if (entity.GetComponent(indexComponent) is IGameContextState)
                {
                    entity.RemoveComponent(indexComponent);
                }
            }
        }

        private static bool CheckTypeEquality(IGameContextState behaviour, StateObjectType type)
        {
            return behaviour.SetSateObjectType().Any(item => item == type);
        }

        public static List<GameEntity> GetRandomElements(List<GameEntity> entities, int uiCount)
        {
            if (entities == null || entities.Count == 0 || uiCount <= 0) return new List<GameEntity>();

            var selectedElements = new List<GameEntity>(uiCount);

            var availableElements = new List<GameEntity>(entities);
            availableElements.Randomize();

            for (var i = 0; i < uiCount; i++)
            {
                if (availableElements.Count == 0) break;

                var totalChance = availableElements.Sum(element => element.chance.value);

                var randomValue = Random.Range(0, totalChance);
                var currentIndex = 0;

                while (randomValue >= 0)
                {
                    randomValue -= availableElements[currentIndex].chance.value;
                    currentIndex++;
                }

                currentIndex = Mathf.Clamp(currentIndex - 1, 0, availableElements.Count - 1);

                var selectedElement = availableElements[currentIndex];
                selectedElements.Add(selectedElement);
                availableElements.RemoveAt(currentIndex);
            }

            return selectedElements;
        }

        public static bool IsInFlatRange(in Vector3 source, in Vector3 target, in float range)
        {
            return GetFlatSqrDistance(source, target) <= range * range;
        }

        public static bool IsInFlatArea(in Vector3 source, in Bounds area)
        {
            return source.x > area.min.x && source.x < area.max.x &&
                   source.z > area.min.z && source.z < area.max.z;
        }

        public static bool IsInArea(in Vector3 source, in Bounds area)
        {
            return source.x > area.min.x && source.x < area.max.x &&
                   source.y > area.min.y && source.y < area.max.y &&
                   source.z > area.min.z && source.z < area.max.z;
        }

        public static Vector3 RandomPointInBound(in Bounds area)
        {
            var randomX = Random.Range(area.min.x, area.max.x);
            var randomY = Random.Range(area.min.y, area.max.y);
            var randomZ = Random.Range(area.min.z, area.max.z);

            return new Vector3(randomX, randomY, randomZ);
        }

        public static Vector3 RandomPointInFlatBound(in Bounds area)
        {
            var randomX = Random.Range(area.min.x, area.max.x);
            var randomZ = Random.Range(area.min.z, area.max.z);

            return new Vector3(randomX, 0, randomZ);
        }

        private static float GetFlatSqrDistance(in Vector3 source, in Vector3 target)
        {
            return new Vector3(source.x - target.x, 0, source.z - target.z).sqrMagnitude;
        }

        public static float GetFlatDistance(in Vector3 source, in Vector3 target)
        {
            return new Vector3(source.x - target.x, 0, source.z - target.z).magnitude;
        }

        public static IEnumerable<T> Randomize<T>(this IEnumerable<T> source)
        {
            var rnd = new System.Random();
            return source.OrderBy(item => rnd.Next());
        }

        public static Vector3 GetBounded(Vector3 position, Bounds bounds)
        {
            if (position.x < bounds.min.x) position.x = bounds.min.x;
            if (position.x > bounds.max.x) position.x = bounds.max.x;

            if (position.z < bounds.min.z) position.z = bounds.min.z;
            if (position.z > bounds.max.z) position.z = bounds.max.z;

            return position;
        }

        public static void DebugState(GameEntity entity)
        {
            foreach (var indexComponent in entity.GetComponentIndices())
            {
                if (entity.GetComponent(indexComponent) is IGameContextState)
                {
                    Debug.Log(entity.GetComponent(indexComponent) + " STATE");
                }
            }
        }
    }
}