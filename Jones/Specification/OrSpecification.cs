﻿using System;
using System.Linq.Expressions;

namespace Jones.Specification
{
    /// <inheritdoc />
    /// <summary>
    /// A Logic OR Specification
    /// </summary>
    /// <typeparam name="T">Type of entity that check this specification</typeparam>
    public sealed class OrSpecification<T> : CompositeSpecification<T> where T : class
    {
        #region Members

        private readonly ISpecification<T> _rightSideSpecification;
        private readonly ISpecification<T> _leftSideSpecification;

        #endregion

        #region Public Constructor

        /// <summary>
        /// Default constructor for AndSpecification
        /// </summary>
        /// <param name="leftSide">Left side specification</param>
        /// <param name="rightSide">Right side specification</param>
        public OrSpecification(ISpecification<T> leftSide, ISpecification<T> rightSide)
        {
            _leftSideSpecification = leftSide ?? throw new ArgumentNullException("leftSide");
            _rightSideSpecification = rightSide ?? throw new ArgumentNullException("rightSide");
        }

        #endregion

        #region Composite Specification overrides

        /// <inheritdoc />
        /// <summary>
        /// Left side specification
        /// </summary>
        public override ISpecification<T> LeftSideSpecification => _leftSideSpecification;

        /// <inheritdoc />
        /// <summary>
        /// Righ side specification
        /// </summary>
        public override ISpecification<T> RightSideSpecification => _rightSideSpecification;

        /// <inheritdoc />
        /// <summary>
        /// <see cref="T:Jones.Specification.ISpecification`1" />
        /// </summary>
        /// <returns><see cref="T:Jones.Specification.ISpecification`1" /></returns>
        public override Expression<Func<T, bool>> SatisfiedBy()
        {
            Expression<Func<T, bool>> left = _leftSideSpecification.SatisfiedBy();
            Expression<Func<T, bool>> right = _rightSideSpecification.SatisfiedBy();

            return left.Or(right);
            
        }

        #endregion
    }
}
